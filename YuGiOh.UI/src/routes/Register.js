//dependencies
import { Form } from '../components/FormLogReg'

//styles
import '../styles/styles-routes/LoginRegister.css'

export function Register(props) 
{
  return (
    <div className="principalContainer">
      <h2 className='head'>Welcome to Yu-Gi-Oh Tournaments</h2>
      <Form
        elements={[
          {
            id: 'Name',
            name: 'Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your name'
          },
          {
            id: 'Nick',
            name: 'Nick Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your nick name'
          },
          {
            id: 'Province',
            name: 'Province',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your province'
          },
          {
            id: 'Township',
            name: 'TownShip',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your township'
          },
          {
            id: 'Address',
            name: 'Address',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your address'
          },
          {
            id: 'PhoneNumber',
            name: 'Phone Number (opcional)',
            inputType: 'number',
            inputPlaceHolder: 'Ingress your phone number'
          },
          {
            id: 'Password',
            name: 'Password',
            inputType: 'password',
            inputPlaceHolder: 'Ingress your password'
          },
          {
            id: 'repeatPassword',
            name: 'Repeat Password',
            inputType: 'password',
            inputPlaceHolder: 'Repeat the password'
          },
          {
            id: 'Code',
            name: 'Admin Code (opcional)',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your code'
          }
        ]} 
        initialForm={{
          Name: '',
          Nick: '',
          Province: '',
          PhoneNumber: '',
          Password: '',
          repeatPassword: '',
          Code: ''
        }}
        buttonText='sign up'
        info={props.info}
        page='register'/>     
    </div>
  )
}

