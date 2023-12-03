//dependencies
import { useEffect } from "react"
import { useFetch } from "./useFetch"
import { useNavigate } from 'react-router-dom'
import { useState } from "react"

export const useRequest = (id, setList, setInfoMessage) => {
  const { infoAPI } = useFetch()
  useEffect(() => infoAPI(`http://localhost:5138/Tournament/available/${id}`, 'GET', setList), [])
  const navigate = useNavigate()
  const [data, setData] = useState({})
  const [archetypeValue, setArchetypeValue] = useState(0)

  const onClickSend = (e) => {
    var bodyRequest = {
      PlayerId: id,
      DeckId: archetypeValue,
      TournamentId: e.target.parentNode.parentNode.firstChild.id,
      StartDate: '',
      Status: ''
    }

    if (archetypeValue == '')
      return

    infoAPI('http://localhost:5138/api/Request/make', 'POST', setData, bodyRequest)

    setInfoMessage({
      header: 'Request sent succesfuly',
      path: '/Login/User/RequestsSettings'
    })

    navigate('/Message')
  }

  const onClickCancel = (e) => {
    infoAPI(`http://localhost:5138/api/Request/delete/${id}/${e.target.parentNode.parentNode.firstChild.id}`, 'DELETE', setData)

    setInfoMessage({
      header: 'Request canceled',
      path: '/Login/User/RequestsSettings/RequestsUser'
    })

    navigate('/Message')
  }

  const onClickAccept = (e) => {
    var bodyRequest = {
      PlayerId: id,
      TournamentId: e.target.parentNode.parentNode.firstChild.id.split(' ')[0],
      DeckId: e.target.parentNode.parentNode.firstChild.id.split(' ')[1],
      Status: 'Approved',
      StartDate: ''
    }

    infoAPI('http://localhost:5138/api/Request/update', 'PUT', setList, bodyRequest)

    setInfoMessage({
      header: 'Request accepted',
      path: '/Login/Admin/RequestsAdmin'
    })

    navigate('/Message')
  }

  const onClickDeny = (e) => {
    var bodyRequest = {
      PlayerId: id,
      TournamentId: e.target.parentNode.parentNode.firstChild.id.split(' ')[0],
      DeckId: e.target.parentNode.parentNode.firstChild.id.split(' ')[1],
      Status: 'Rejected',
      StartDate: ''
    }

    infoAPI('http://localhost:5138/api/Request/update', 'PUT', setList, bodyRequest)

    setInfoMessage({
      header: 'Request rejected',
      path: '/Login/Admin/RequestsAdmin'
    })

    navigate('/Message')
  }

  return {
    onClickSend,
    onClickCancel,
    setArchetypeValue,
    onClickAccept,
    onClickDeny
  }
}