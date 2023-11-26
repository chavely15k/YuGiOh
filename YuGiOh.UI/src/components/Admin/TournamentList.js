//dependencies
import { AiFillCloseCircle } from "react-icons/ai";
import { NavLink } from 'react-router-dom';

//styles
import '../../styles/Admin/TournamentList.css'

export function TournamentList(props) {
  return (
    <div className="containerTournaments">
      <div className="tournamentsHead">
        <h3>My Tournaments</h3>
      </div>
      <ul className="containerList">
        {props.list.map(element => (
          <div className="containerLi">
            <li 
              key={element.id}
              id={element.id}>
                {element.name}
            </li>
            <div 
              className="containerElim"
              onClick={props.onClickDelete}>
                <AiFillCloseCircle/>
            </div>
          </div>
        ))}
      </ul>
      <NavLink 
        to='/Login/Admin/AddTournament'
        className='buttonTournament'>
          add tournament
      </NavLink>
    </div>
  )
}