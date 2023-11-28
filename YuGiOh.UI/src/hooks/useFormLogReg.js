//dependencies
import { useState } from "react"
import { useNavigate } from 'react-router-dom'

export const useForm = (initialForm, info, page) => {
  const [formState, setFormState] = useState(initialForm)
  var newFormState = {}
  const navigate = useNavigate()
  const [data, setData] = useState({})

  const onInputChange = (e) => {
    formState[e.target.id] = e.target.value
    setFormState(formState)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()

    for (let element in formState) 
    {
      if (formState[element] == '' && (element != 'PhoneNumber' && element != 'Code')) 
      {
        alert(`Should fill all the required input's fields`)
        return
      }

      if (element == 'repeatPassword' && formState.Password != formState[element]) 
      {
        alert(`Password's and Repeat Password's fields doesn't match`)
        return
      }

      if (element == 'Code') 
      {
        formState[element] == ''
          ? newFormState = {
            ...newFormState,
            [element]: formState[element],
            Roles: [1]
          }
          : newFormState = {
            ...newFormState,
            [element]: formState[element],
            Roles: [0, 1]
          }
      }

      else if (element != 'repeatPassword') {
        newFormState = {
          ...newFormState,
          [element]: formState[element]
        }
      }
    }

    getInfoAPI()
    //console.log(data)
    //navigate(`${page == 'register' ? '/' : '/Login/Admin'}`)
  }

  const getInfoAPI = () => {
    fetch('http://localhost:5138/Account/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(newFormState)
    })
      .then(response => response.json())
      .then(info => console.log(info))
      .catch(error => alert(`An error has occurred: ${error}`))
  }

  return {
    onInputChange,
    onClickSubmit
  }


}