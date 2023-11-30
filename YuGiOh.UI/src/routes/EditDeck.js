//components
import { Form } from "../components/FormTournamentDeck"

//styles
import '../styles/styles-routes/EditAddTournament.css'

export function EditDeck(props) 
{
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
        nameButton='edit'
        initialForm={{
          Name: '',
          MainDeckSize: '',
          ExtraDeckSize: '',
          SideDeckSize: '',
          Archetype: ''
        }} 
        page='editDeck'/>
    </div>
  )
}