import { useState } from "react"
import { useFetch } from "./useFetch"

export const useMatch = (initialForm, playerOneId, playerTwoId, group, round, tournament, setOnSend) => {
  const [formMatch, setFormMatch] = useState(initialForm)
  const { infoAPI } = useFetch()
  const [data, setData] = useState({})
  
  const onInputChange = (e) => {
    formMatch[e.target.id] = e.target.value
    setFormMatch(formMatch)
  }

  const onClickSubmitMatch = (e) => {
    e.preventDefault()

    for(let element in formMatch)
    {
      if(formMatch[element] == '')
      {
        alert("Should fill all input's fields")
        return
      }
    }

    var bodyRequest = {
      ...formMatch,
      PlayerOneId: playerOneId,
      PlayerTwoId: playerTwoId,
      Group: group,
      Round: round,
      TournamentId: tournament
    }

    bodyRequest.Date += 'Z'

    infoAPI('http://localhost:5138/api/Match/create', 'POST', setData, bodyRequest)
    setOnSend(false)
  }

  return {
    onInputChange,
    onClickSubmitMatch
  }
}