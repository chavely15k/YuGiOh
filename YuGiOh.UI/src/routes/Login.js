//components
import { useState } from 'react'
import { Form } from '../components/FormLogReg'
import { Rol } from './Rol'

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
            id: 'Nick',
            name: 'User Name',
            inputType: 'text',
            inputPlaceHolder: 'Ingress your user name'
          },
          {
            id: 'Password',
            name: 'Password',
            inputType: 'password',
            inputPlaceHolder: 'Ingress your password'
          }
        ]} 
        initialForm={{
          Nick: '',
          Password: ''
        }}
        buttonText='sign in'
        info={props.info}
        page='login'/>
    </div>
  )
}
