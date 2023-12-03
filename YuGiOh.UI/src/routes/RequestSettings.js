//dependencies
import { useRequest } from "../hooks/useRequest"
import { useState } from "react"
import { useEffect } from "react"

///components
import { Archetype } from "../components/Archetype"
import { List } from "../components/List"

//styles
import '../styles/styles-routes/RequestsSettings.css'

export function RequestsSettings(props) 
{
  const [list, setList] = useState([])
  const { onClickSend, setArchetypeValue } = useRequest(props.info.id, setList, props.setInfoMessage)

  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login/User')
  }, [])

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
          page='posibleRequestsUser'
          onClickSend={onClickSend}/>
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