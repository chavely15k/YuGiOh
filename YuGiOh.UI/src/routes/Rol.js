import { Button } from '../components/PrincipalPage/Button'
import '../styles/styles-routes/Rol.css'

export function Rol() {
  return (
    <div className='containerPrincipalRol'>
      <form className="containerFormRol">
        <p className="headerRol">How do you want to ingress</p>
        <div className="containerButtonsRol">
          <Button path='/Login/Admin'>Admin</Button>
          <Button path='/Login/User'>User</Button>
        </div>
      </form>
    </div>
  )
}