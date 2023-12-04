//dependencies
import { useState } from "react"
import { useFetch } from "./useFetch"
import { useNavigate } from 'react-router-dom'

export const useUser = () => {
  const [code, setCode] = useState('')
  const { infoAPI } = useFetch()
  const [valid, setValid] = useState(false)
  const navigate = useNavigate()

  const onInputChange = (e) => {
    setCode(e.target.value)
  }

  const onClickSubmit = (e) => {
    infoAPI('url', 'POST', setValid, code)

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