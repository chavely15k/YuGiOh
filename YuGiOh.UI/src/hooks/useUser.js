//dependencies
import { useState } from "react"
import { useFetch } from "./useFetch"
import { useNavigate } from 'react-router-dom'

export const useUser = (id) => {
  const [code, setCode] = useState('')
  const { infoAPI } = useFetch()
  var data = [false]
  const navigate = useNavigate()

  const almac = (value) => {
    data[0] = value
  }

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
    infoAPI('http://localhost:5138/Account/BeAdmin', 'PUT', almac, bodyRequest)

    setTimeout(() => {
      var valid = data[0]
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