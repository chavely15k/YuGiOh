//dependencies
import { NavLink } from 'react-router-dom';

//styles
import '../styles/Button.css';

export function Button(props)
{
  return(
    <NavLink 
      to={props.path} 
      className='button'>
        {props.children}
    </NavLink>
  )
}