//dependencies
import { useForm } from "../hooks/useFormTournamentDeck"

//styles
import '../styles/FormEA.css'

export function Form(props) {
  const { onClickSubmit, onInputChange } = useForm(props.initialForm, props.id, props.page)

  return (
    <form
      className="formEA"
      onSubmit={onClickSubmit}>
      <div className="containerFieldsEA">
        {props.elements.map(element => (
          <div
            className="row"
            key={element.id}>
            <label
              htmlFor={`${element.id}`}
              className="labelEA">
              {element.name}
            </label>
            <input
              className="inputEA"
              id={`${element.id}`}
              type={`${element.inputType}`}
              name={`${element.id}`}
              placeholder={`${element.inputPlaceHolder}`}
              onChange={onInputChange} />
          </div>
        ))}
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