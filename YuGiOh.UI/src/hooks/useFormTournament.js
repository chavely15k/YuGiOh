import { useState } from "react"
import { useNavigate } from 'react-router-dom'

export const useForm = (initialForm) => {
  const [formState, setFormState] = useState(initialForm)
  const navigate = useNavigate()

  const onInputChange = (e) => {
    formState[e.target.id] = e.target.value
    setFormState(formState)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()

    for (let element in formState) 
    {
      if (formState[element] == '') 
      {
        alert(`Should fill all the input's fields`)
        return
      }
    }

    navigate('/Login/Admin')
    console.log(formState)
  }

  return {  
    onInputChange,
    onClickSubmit
  }
}