//dependencies
import { useState } from "react"

export const useForm = (initialForm) => {
  const [formState, setFormState] = useState(initialForm)

  const onInputChange = (e) => {
    formState[e.target.id] = e.target.value
	  setFormState(formState)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()
    var newFormState = {}

		for(let element in formState)
		{
			if(formState[element] == '' && (element != 'phoneNumber' || element != 'adminCode'))
				{  
					alert(`Should fill all the required input's fields`)
					return
				}
      
      if(element != 'repeatPassword')
      {
        newFormState = {
          ...newFormState,
          [element]: formState[element]
        }
      }      
      
      if(element == 'repeatPassword' && formState.password != formState[element])
      {
        alert(`Password's and Repeat Password's fields doesn't match`)
        return
      }
		}

    console.log(newFormState)
  }

  return {
    onInputChange, 
    onClickSubmit
  }
}