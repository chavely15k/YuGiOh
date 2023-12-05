import { useState } from "react"
import { useMatch } from "../hooks/useMatch"
import '../styles/FormMatch.css'

export function Form(props) {
  const [onSend, setOnSend] = useState(true)
  
  const { onInputChange, onClickSubmitMatch } = useMatch({
    PlayerOneResult: '',
    PlayerTwoResult: '',
    Date: ''
  }, props.playerOneId, props.playerTwoId, props.group, props.round, props.tournamentId, setOnSend)

  return (
    <form
      className='formMatch'
      onSubmit={onClickSubmitMatch}>
      <div className="match">
        <div className="player">
          <label
            className='playerName'>
            {props.playerOneNick}
          </label>
          <input
            className="result"
            id='PlayerOneResult'
            type='number'
            onChange={onInputChange} />
        </div>
        <div className="player">
          <label
            className='playerName'>
            {props.playerTwoNick}
          </label>
          <input
            className="result"
            id='PlayerTwoResult'
            type='number'
            onChange={onInputChange} />
        </div>
        <label>
        <label
            className='playerName'>
             date:
          </label>
          <input
            className="result date"
            id='Date'
            type='datetime-local'
            onChange={onInputChange} />
        </label>
      </div>
      {onSend &&
      <button
        className='buttonSubmitMatch'
        type='Submit'>
        send
      </button>}
    </form>
  )
}