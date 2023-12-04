//dependencies
import { useState } from "react"
import { useFetch } from "./useFetch"
import { useNavigate } from 'react-router-dom'

export const useUser = (id) => {
  const [code, setCode] = useState('')
  const { infoAPI } = useFetch()
  const [valid, setValid] = useState(false)
  const navigate = useNavigate()

  const onInputChange = (e) => {
    setCode(e.target.value)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()

    var bodyRequest = {
      Id: id,
      Code: code,  
      Roles: [0]
    }

    console.log(bodyRequest)
    infoAPI('http://localhost:5138/Account/BeAdmin', 'PUT', setValid, bodyRequest)

    setTimeout(() => {
      if (valid)
        navigate('/Login')

      else {
        alert('Invalid code')
        navigate('/Login/User')
      }
    }, 1000)
  }

  return {
    onInputChange,
    onClickSubmit
  }
}