//components
import { Button } from '../components/PrincipalPage/Button';

//dependencies
import { AiFillTrophy } from "react-icons/ai";

//styles
import '../styles/styles-routes/PrincipalPage.css'

export function PrincipalPage() {
  return (
    <div className='principalContainer'>
      <div className='containerLogo'><AiFillTrophy size={120} /></div>
      <div className='containerOptions'>
        <div className='containerButtons'>
          <Button
            path='/Login'>
            Login
          </Button>
          <Button
            path='/Register'>
            Register
          </Button>
        </div>
        <footer>
          <p>Already have an account: <b>Login</b></p>
          <p>You are new here: <b>Register</b></p>
        </footer>
      </div>
    </div>
  );
}