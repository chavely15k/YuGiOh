//dependencies
import { useEffect } from "react"
import { useState } from "react"

//components
import { Form } from "../components/FormTournamentDeck"
import { Archetype } from "../components/Archetype"

//styles
import '../styles/styles-routes/EditAddTournamentDeck.css'

export function EditDeck(props) 
{
  const [archetypeValue, setArchetypeValue] = useState('')

  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login/User/Decks')
  }, [])

  return (
    <div className="containerEdit">
      <h2 className="headForm">Edit Deck</h2>
      <Form
        elements={[
          {
            id: 'Name',
            name: 'Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your user deck name'
          },
          {
            id: 'MainDeckSize',
            name: 'Main Deck Cards',
            inputType: 'number',
            inputPlaceHolder: 'Ingress a maindeck size'
          },
          {
            id: 'ExtraDeckSize',
            name: 'ExtraDeck Cards (opcional)',
            inputType: 'number',
            inputPlaceHolder: 'Ingress a extradeck size'
          },
          {
            id: 'SideDeckSize',
            name: 'SideDeck Cards (opcional)',
            inputType: 'number',
            inputPlaceHolder: 'Ingress a extradeck size'
          }
        ]}
        nameButton='edit'
        initialForm={{
          Name: '',
          MainDeckSize: '',
          ExtraDeckSize: '',
          SideDeckSize: ''
        }} 
        id={props.info.id} 
        page='editDeck'
        infoEditDeckTournament={props.infoEditDeckTournament}
        archetype={archetypeValue}/>
        <Archetype 
          setArchetypeValue={setArchetypeValue}
          url='http://localhost:5138/Archetype/get'
          name='Archetype'/>
    </div>
  )
}