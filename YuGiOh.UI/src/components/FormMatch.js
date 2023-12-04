import { useMatch } from "../hooks/useMatch"
import '../styles/FormMatch.css'

export function Form(props) {
  const { onInputChange, onClickSubmitMatch } = useMatch({
    playerOneResult: '',
    playerTwoResult: '',
    date: ''
  })

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
            id='playerOneResult'
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
            id='playerTwoResult'
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
            id='date'
            type='datetime-local'
            onChange={onInputChange} />
        </label>
      </div>
      <button
        className='buttonSubmitMatch'
        type='Submit'>
        send
      </button>
    </form>
  )
}