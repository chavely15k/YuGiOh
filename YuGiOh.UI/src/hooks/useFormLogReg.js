//dependencies
import { useState } from "react"
import { useNavigate } from 'react-router-dom'
import { useFetch } from "./useFetch"

export const useForm = (initialForm, info, page) => {
  const [formState, setFormState] = useState(initialForm)
  var newFormState = {}
  const navigate = useNavigate()
  const data = [{}]
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
        if (element == 'PhoneNumber' && formState[element] == '')
          continue

        newFormState = {
          ...newFormState,
          [element]: formState[element]
        }
      }
    }

    const almac = (value) => {
      data[0] = value
    }

    infoAPI(`http://localhost:5138/Account/${page}`, 'POST', almac, newFormState)

    setTimeout(() => {
      const newData = data[0]

      if (!newData.success) {
        alert(newData.message)
        return
      }

      if (page == 'register') {
        navigate('/Login')
        return
      }

      info(newData)
      navigate(`${newData.roles.length > 1 ? '/Login/Rol' : '/Login/User'}`)
    }, 1000)

  }

  return {
    onInputChange,
    onClickSubmit
  }


}