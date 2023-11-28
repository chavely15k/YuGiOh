import { Form } from "../components/FormAdmin"
import '../styles/styles-routes/EditAddTournament.css'

export function AddTournament()
{
  return (
    <div className="containerEdit">
      <h2 className="headForm">Create Tournament</h2>
      <Form 
        nameButton='add'
        initialForm={{
          nameTournament: '',
          dateTournament: '',
          addressTournament: ''
        }}/>
    </div>
  )
}