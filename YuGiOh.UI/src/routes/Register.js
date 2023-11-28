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
            id: 'name',
            name: 'Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your name'
          },
          {
            id: 'nickname',
            name: 'Nick Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your nick name'
          },
          {
            id: 'province',
            name: 'Province',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your province'
          },
          {
            id: 'township',
            name: 'TownShip',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your township'
          },
          {
            id: 'address',
            name: 'Address',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your address'
          },
          {
            id: 'phoneNumber',
            name: 'Phone Number (opcional)',
            inputType: 'number',
            inputPlaceHolder: 'Ingress your phone number'
          },
          {
            id: 'password',
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
            id: 'adminCode',
            name: 'Admin Code (opcional)',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your code'
          }
        ]} 
        initialForm={{
          name: '',
          nickname: '',
          province: '',
          phoneNumber: '',
          password: '',
          repeatPassword: '',
          adminCode: ''
        }}
        buttonText='sign up'
        data={props.data}
        page='register'/>     
    </div>
  )
}

