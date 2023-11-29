//dependencies
import { Form } from "../components/FormAdmin"

//styles
import '../styles/styles-routes/EditAddTournament.css'

export function EditTournament() 
{
  return (
    <div className="containerEdit">
      <h2 className="headForm">Edit Tournament</h2>
      <Form
        elements={[
          {
            id: 'Name',
            name: 'Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your user tournament name'
          },
          {
            id: 'StartDate',
            name: 'Date',
            inputType: 'datetime-local',
            inputPlaceHolder: 'Ingress a valid date'
          },
          {
            id: 'Address',
            name: 'Address',
            inputType: 'text',
            inputPlaceHolder: 'Ingress a valid address'
          }
        ]}
        nameButton='edit'
        initialForm={{
          nameTournament: '',
          dateTournament: '',
          addressTournament: ''
        }} />
    </div>
  )
}