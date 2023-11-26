//dependencies
import { useForm } from "../hooks/useFormLogReg"

//styles
import "../styles/Form.css"

export function Form(props) 
{
  const { onInputChange, onClickSubmit } = useForm(props.initialForm)

  return (
    <form 
      onSubmit={onClickSubmit}
      className="formLR">
      <div className="containerFields">
        {props.elements.map(element => (
          <div
            className="containerRow"
            key={element.id}>
            <label 
              htmlFor={`${element.id}`}
              className="labelLR">
                {element.name}
            </label>
            <input
              className="inputLR"
              id={`${element.id}`}
              type={`${element.inputType}`}
              name={`${element.id}`}
              placeholder={`${element.inputPlaceHolder}`}
              onChange={onInputChange} />
          </div>
        ))}
      </div>
      <div className="containerButtonLR">
        <button 
          type="Submit"
          className="buttonLR">
            {props.buttonText}
        </button>
      </div>
    </form>
  )
}