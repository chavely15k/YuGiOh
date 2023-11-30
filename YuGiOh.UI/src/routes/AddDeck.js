//components
import { Form } from "../components/FormTournamentDeck"

//styles
import '../styles/styles-routes/EditAddTournament.css'

export function AddDeck(props) 
{
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
          },
          {
            id: 'Archetype',
            name: 'Archetype',
            inputType: 'text',
            inputPlaceHolder: 'ingress a valid archetype'
          }
        ]}
        nameButton='add'
        initialForm={{
          Name: '',
          MainDeckSize: '',
          ExtraDeckSize: '',
          SideDeckSize: '',
          Archetype: ''
        }}
        id={props.info.id} 
        page='addDeck'/>
    </div>
  )
}