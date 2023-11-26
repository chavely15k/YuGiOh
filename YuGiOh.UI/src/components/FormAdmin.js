import { useForm } from "../hooks/useFormTournament";
import '../styles/Form.css'

export function Form(props) {
  const { onClickSubmit, onInputChange } = useForm(props.initialForm)

  return (
    <form
      className="formLR"
      onSubmit={onClickSubmit}>
      <div className="containerFields">
        <div className="containerRow">
          <label
            htmlFor="nameTournament"
            className="labelTournament labelLR">
            Name
          </label>
          <input
            className="inputLR"
            id="nameTournament"
            type="text"
            name="name"
            onChange={onInputChange}
            placeholder="Ingress a tournament name"/>
        </div>
        <div className="containerRow">
          <label
            htmlFor="dateTournament"
            className="labelTournament labelLR">
            Date
          </label>
          <input
            className="inputLR"
            id="dateTournament"
            type="date"
            name="date"
            onChange={onInputChange}
            placeholder="Ingress a tournament date"/>
        </div>
        <div className="containerRow">
          <label
            htmlFor="addressTournament"
            className="labelTournament labelLR">
            Address
          </label>
          <input
            className="inputLR"
            id="addressTournament"
            type="text"
            name="address"
            onChange={onInputChange}
            placeholder="Ingress a tournament address"/>
        </div>
      </div>
      <div className="containerButtonLR">
        <button
          className="buttonLR"
          type="Submit">
          {props.nameButton}
        </button>
      </div>
    </form>
  )
}