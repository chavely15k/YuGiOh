import { useForm } from "../hooks/useFormTournament";
import '../styles/FormEA.css'

export function Form(props) {
  const { onClickSubmit, onInputChange } = useForm(props.initialForm)

  return (
    <form
      className="formEA"
      onSubmit={onClickSubmit}>
      <div className="containerFieldsEA">
        <div className="row">
          <label
            htmlFor="nameTournament"
            className="labelTournament labelEA">
            Name
          </label>
          <input
            className="inputEA"
            id="nameTournament"
            type="text"
            name="name"
            onChange={onInputChange}
            placeholder="Ingress a tournament name"/>
        </div>
        <div className="row">
          <label
            htmlFor="dateTournament"
            className="labelTournament labelEA">
            Date
          </label>
          <input
            className="inputEA"
            id="dateTournament"
            type="date"
            name="date"
            onChange={onInputChange}
            placeholder="Ingress a tournament date"/>
        </div>
        <div className="row">
          <label
            htmlFor="addressTournament"
            className="labelTournament labelEA">
            Address
          </label>
          <input
            className="inputEA"
            id="addressTournament"
            type="text"
            name="address"
            onChange={onInputChange}
            placeholder="Ingress a tournament address"/>
        </div>
      </div>
      <div className="containerButtonEA">
        <button
          className="buttonEA"
          type="Submit">
          {props.nameButton}
        </button>
      </div>
    </form>
  )
}