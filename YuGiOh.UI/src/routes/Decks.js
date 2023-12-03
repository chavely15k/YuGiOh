//dependencies
import { useState, useEffect } from "react"
import { useAdminDeck } from "../hooks/useAdminDeck"
import { useFetch } from "../hooks/useFetch"

//components
import { List } from "../components/List"

//styles
import '../styles/styles-routes/Decks.css'

export function Decks(props)
{
  const [list, setList] = useState([])
  const { onClickDelete, onClickEdit } = useAdminDeck(setList, props.setInfoMessage, 'decks', props.setInfoEditDeckTournament)
  const { infoAPI } = useFetch()

  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login/User')
    infoAPI(`http://localhost:5138/Deck/userId/${props.info.id}`, 'GET', setList) 
  }, [])
  
  return (
    <div className='user'>
      <div className='containerHeadUser'>
        <h2>Deck Settings</h2>
      </div>
      <div className='principalContentUser'>
        <List 
          list={list}
          onClickDelete={onClickDelete}
          onClickEdit={onClickEdit}
          header='My Decks'
          addPage='/Login/User/Decks/AddDeck'
          nameAddPage='add deck'
          page='decks'/>
      </div>
    </div>
  )
}