import { useEffect, useState } from "react"

export const useFetch = () => {
  const [data, setData] = useState({})

  const infoAPI = (url, method, almac)
  useEffect(() => {
    console.log(object)
    fetch('http://localhost:5138/Account/register', {
      method: 'POST',
      body: JSON.stringify(object),
      headers: {
        'Content-Type': 'aplication/json'
      }})
    .then(response => response.json)
    .then(info => setData(info))
    .catch(error => alert(`An error has occurred: ${error}`))
  }, [])

  return {
    data
  }
}
