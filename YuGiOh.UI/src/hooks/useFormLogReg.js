//dependencies
import { useState } from "react"
import { useNavigate } from 'react-router-dom'
import { useFetch } from "./useFetch"

export const useForm = (initialForm, info, page) => {
  const [formState, setFormState] = useState(initialForm)
  var newFormState = {}
  const navigate = useNavigate()
  const [data, setData] = useState({})
  const { infoAPI } = useFetch()

  const onInputChange = (e) => {
    formState[e.target.id] = e.target.value
    setFormState(formState)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()

    for (let element in formState) {
      if (formState[element] == '' && (element != 'PhoneNumber' && element != 'Code')) {
        alert(`Should fill all the required input's fields`)
        return
      }

      if (element == 'repeatPassword' && formState.Password != formState[element]) {
        alert(`Password's and Repeat Password's fields doesn't match`)
        return
      }

      if (element == 'Code') {
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

    infoAPI(`'http://localhost:5138/Account/${page}`,
      `${page == 'register' ? 'POST' : 'GET'}`, setData, newFormState)

    if(!data.success)
    {
      alert(data.message)
      return
    }

    if(page == 'register')
    {
      navigate('/Login')
      return
    }
      
    info({
      id: data.id,
      Nick: data.Nick,
      Roles: data.Roles
    })

    navigate(`${data.Roles.length > 1 ? '.Login/Rol' : 'Login/User'}`)
  }

  return {
    onInputChange,
    onClickSubmit
  }


}