//dependencies
import { NavLink } from 'react-router-dom';

//components
import { AiFillCloseCircle } from "react-icons/ai";
import { AiTwotoneEdit } from "react-icons/ai";

//styles
import '../../styles/Admin/TournamentList.css'

export function TournamentList(props) 
{
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
              {element.name}/{element.address}/{element.startDate}
            </li>
            <div className="containerIcons">
              <div
                className="containerIcon editIcon"
                onCLick={props.onClickEdit}>
                  <AiTwotoneEdit />
              </div>
              <div
                className="containerIcon deleteIcon"
                onClick={props.onClickDelete}>
                  <AiFillCloseCircle />
              </div>
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