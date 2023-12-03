//dependencies
import { useEffect } from 'react'

//components
import { Form } from '../components/FormLogReg'

//styles
import '../styles/styles-routes/LoginRegister.css'

export function Login(props) 
{
  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/')
  }, [])

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
