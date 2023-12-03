//dependencies
import { useEffect } from "react"
import { useState } from "react"

//components
import { Archetype } from "../components/Archetype"
import { Form } from "../components/FormTournamentDeck"

//styles
import '../styles/styles-routes/EditAddTournamentDeck.css'

export function AddDeck(props) 
{
  const [archetypeValue, setArchetypeValue] = useState(0)

  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login/User/Decks')
  }, [])

  return (
    <div className="containerEdit">
      <h2 className="headForm">Create Deck</h2>
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
            name: 'ExtraDeck Cards',
            inputType: 'number',
            inputPlaceHolder: 'Ingress a extradeck size'
          },
          {
            id: 'SideDeckSize',
            name: 'SideDeck Cards',
            inputType: 'number',
            inputPlaceHolder: 'Ingress a extradeck size'
          }
        ]}
        nameButton='add'
        initialForm={{
          Name: '',
          MainDeckSize: '',
          ExtraDeckSize: '',
          SideDeckSize: ''
        }}
        id={props.info.id} 
        page='addDeck'
        archetype={archetypeValue}/>
        <Archetype 
          setArchetypeValue={setArchetypeValue}
          url='http://localhost:5138/Archetype/get'
          name='Archetype'/>
    </div>
  )
}