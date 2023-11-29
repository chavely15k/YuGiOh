export const useFetch = () => {

  const infoAPI = (url, method, almac, object) => {
    method != 'GET'
      ?
      fetch(url, {
        method: method,
        body: JSON.stringify(object),
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(response => response.json())
        .then(info => almac(info))
        .catch(error => alert(`An error has occurred: ${error}`))
      :
      fetch(url)
        .then(response => response.json())
        .then(info => almac(info))
        .catch(error => alert(`An error has occurred: ${error}`))
  }

  return {
    infoAPI
  }  
}

