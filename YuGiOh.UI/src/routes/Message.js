//components
import { Button } from "../components/Button"

//styles
import '../styles/styles-routes/Message.css'

export function Message(props) 
{
  return (
    <div className='containerPrincipalMessage'>
      <div className="containerOptionsMessage">
        <h2 className="headerMessage">{props.infoMessage.header}</h2>
        <Button path={props.infoMessage.path}>Aceptar</Button>
      </div>
    </div>
  )
}