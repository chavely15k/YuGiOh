//components
import { NavLink } from 'react-router-dom'
import { Form } from '../components/FormLogReg'

//styles
import '../styles/styles-routes/LoginRegister.css'

export function Login(props) 
{
  return (
    <div className='principalContainer'>
      <h2 className='head'>Login to your account</h2>
      <Form
        elements={[
          {
            id: 'userName',
            name: 'User Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your user name'
          },
          {
            id: 'password',
            name: 'Password',
            inputType: 'password',
            inputPlaceHolder: 'Ingress your password'
          }
        ]} 
        initialForm={{
          userName: '',
          password: ''
        }}
        buttonText='sign in'
        info={props.info}
        page='login'/>
    </div>
  )
}
