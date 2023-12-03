//dependencies
import { useEffect } from 'react'

//components
import { Button } from '../components/Button'

//styles
import '../styles/styles-routes/Rol.css'

export function Rol(props) 
{
  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login')
  }, [])

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