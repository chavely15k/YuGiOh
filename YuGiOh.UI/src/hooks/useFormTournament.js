//dependencies
import { useState } from "react"
import { useNavigate } from 'react-router-dom'
import { useFetch } from "./useFetch"

export const useForm = (initialForm, id) => {
  const [formState, setFormState] = useState(initialForm)
  const navigate = useNavigate()
  const { infoAPI } = useFetch()
  const data = [{}]

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

    const newFormState = {
      ...formState,
      AdminId: id
    }

    newFormState.StartDate += 'Z'

    const almac = (value) => {
      data[0] = value
    }

    infoAPI('http://localhost:5138/Tournament/create', 'POST', almac, newFormState)

    setTimeout(() => {
      console.log(data[0])
    }, 2000)
    
    navigate('/Login/Admin')
  }

  return {  
    onInputChange,
    onClickSubmit
  }
}