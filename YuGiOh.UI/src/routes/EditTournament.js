import { Form } from "../components/FormAdmin"
import '../styles/styles-routes/EditAddTournament.css'

export function EditTournament()
{
  return (
    <div className="containerEdit">
      <h2 className="headForm">Edit Tournament</h2>
      <Form 
        nameButton='edit'
        initialForm={{
          nameTournament: '',
          dateTournament: '',
          addressTournament: ''
        }}/>
    </div>
  )
}