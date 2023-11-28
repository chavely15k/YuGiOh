//dependencies
import { useState } from "react"
import { useNavigate } from 'react-router-dom'
import { Register } from "../routes/Register"

export const useForm = (initialForm, data, page) => {
  const [formState, setFormState] = useState(initialForm)
  var newFormState = {}
  const navigate = useNavigate()

  const onInputChange = (e) => {
    formState[e.target.id] = e.target.value
	  setFormState(formState)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()

		for(let element in formState)
		{
			if(formState[element] == '' && (element != 'phoneNumber' && element != 'adminCode'))
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

    data({
      ...newFormState,
      id: 1
    })

    navigate(`${page == 'register' ? '/' : '/Login/Admin'}`)
  }

  return {
    onInputChange, 
    onClickSubmit
  }

 
}