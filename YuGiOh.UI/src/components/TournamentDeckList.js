//dependencies
import { NavLink } from 'react-router-dom';

//components
import { AiFillCloseCircle } from "react-icons/ai";
import { AiTwotoneEdit } from "react-icons/ai";

//styles
import '../styles/TournamentDeckList.css'

export function List(props) 
{
  return (
    <div className="containerTournamentsDecks">
      <div className="tournamentsDecksHead">
        <h3>{props.header}</h3>
      </div>
      <ul className="containerList">
        {props.list.map(element => (
          <div className="containerLi">
            <li
              key={element.id}
              id={element.id}>
              {element.name} / {element.address} / {element.startDate}
            </li>
            <div className="containerIcons">
              <div
                className="containerIcon editIcon"
                onClick={props.onClickEdit}>
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
        to={props.addPage}
        className='buttonTournament'>
          {props.nameAddPage}
      </NavLink>
    </div>
  )
}