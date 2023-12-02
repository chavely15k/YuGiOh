import { useEffect, useState } from "react"
import { Archetype } from "../components/Archetype"
import { useFetch } from "../hooks/useFetch"
import { List } from "../components/TournamentDeckList"
import '../styles/styles-routes/RequestsSettings.css'

export function RequestsSettings(props) {
  const [archetypeValue, setArchetypeValue] = useState(0)
  const { infoAPI } = useFetch()
  const [data, setData] = useState({})
  const [list, setList] = useState([])
  useEffect(() => infoAPI('http://localhost:5138/Tournament/All', 'GET', setList), [])

  const onClickChange = (e) => {
    var bodyRequest = {
      PlayerId: props.info.id,
      DeckId: archetypeValue,
      TournamentId: e.target.parentNode.parentNode.firstChild.id
    }

    if (archetypeValue == '')
      return

    infoAPI('http://localhost:5138/api/Request/make', 'POST', setData, bodyRequest)

    props.setInfoMessage({
      header: 'Request sent succesfuly',
      path: '/Login/User/RequestSettings'
    })
  }

  return (
    <div className="principalContainerRequests">
      <div className="tournamentsRequestsHead">
        <h2>Requests Settings</h2>
      </div>
      <div className="containerTournamentsRequests">
        <List
          list={list}
          header='Available Tournaments'
          addPage='/Login/User/Decks/RequestSettings/Requests'
          nameAddPage='requests'
          page='requestsUser'
          onClickChange={onClickChange} />
      </div>
      <div className="containerArchetype">
        <Archetype
          setArchetypeValue={setArchetypeValue}
          url={`http://localhost:5138/Deck/userId/${props.info.id}`}
          name='My Decks' />
      </div>
    </div>
  )
}