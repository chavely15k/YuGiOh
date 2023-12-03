//dependencies
import { NavLink } from 'react-router-dom';

//styles
import '../styles/List.css'

export function List(props) {
  return (
    <div className="containerTournamentsDecks">
      <div className="tournamentsDecksHead">
        <h3>{props.header}</h3>
      </div>
      <ul className="containerList">
        {props.page == 'admin'
          ?
          props.list.map(element => (
            <div className="containerLi">
              <li
                key={element.id}
                id={element.id}>
                Name: {element.name} || {element.address} || {element.startDate} || Users: {element.signedPlayers}
              </li>
              <div className="containerIcons">
                <div
                  className="containerIcon editIcon"
                  onClick={props.onClickEdit}>
                  e
                </div>
                <div
                  className="containerIcon deleteIcon"
                  onClick={props.onClickDelete}>
                  x
                </div>
              </div>
            </div>
          ))
          : props.page == 'decks'
            ?
            props.list.map(element => (
              <div className="containerLi">
                <li
                  key={element.id}
                  id={element.id}>
                  Name: {element.name} || Main: {element.mainDeckSize} || Extra: {element.extraDeckSize} || Side Deck: {element.sideDeckSize} || {element.archetypeName}
                </li>
                <div className="containerIcons">
                  <div
                    className="containerIcon editIcon"
                    onClick={props.onClickEdit}>
                    e
                  </div>
                  <div
                    className="containerIcon deleteIcon"
                    onClick={props.onClickDelete}>
                    x
                  </div>
                </div>
              </div>
            ))
            : props.page == 'posibleRequestsUser'
              ?
              props.list.map(element => (
                <div className="containerLi">
                  <li
                    key={element.id}
                    id={element.id}>
                    Name: {element.name} || {element.address} || {element.startDate}
                  </li>
                  <div className="containerActionRequest">
                    <p
                      onClick={props.onClickSend}
                      className='actionRequest actionRequestSend'>
                      send
                    </p>
                  </div>
                </div>
              ))
              : props.page == 'userTournaments'
                ?
                props.list.map(element => (
                  <div className="containerLi">
                    <li
                      key={element.id}
                      id={element.id}>
                      Name: {element.name} || {element.address} || {element.startDate}
                    </li>
                  </div>
                ))
                :
                props.list.map(element => (
                  <div className="containerLi">
                    <li
                      key={element.tournamentId}
                      id={element.tournamentId}>
                        {element.tournamentName}
                    </li>
                    <div className='containerActionRequest'>
                      <p
                        className='actionRequest actionRequestCancel'
                        onClick={props.onClickCancel}>
                          cancel
                      </p>
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