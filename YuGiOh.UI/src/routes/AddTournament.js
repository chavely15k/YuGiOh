//dependencies
import { useEffect } from "react"

//components
import { Form } from "../components/FormTournamentDeck"

//styles
import '../styles/styles-routes/EditAddTournamentDeck.css'

export function AddTournament(props)
{
  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login/Admin')
  }, [])

  return (
    <div className="containerEdit">
      <h2 className="headForm">Create Tournament</h2>
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
        nameButton='add'
        initialForm={{
          Name: '',
          StartDate: '',
          Address: ''
        }}
        id={props.info.id}
        page='addTournament'/>
    </div>
  )
}