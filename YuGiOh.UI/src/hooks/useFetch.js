export const useFetch = () => {

  const infoAPI = (url, method, save, object) => {
    method == 'POST' || method == 'PUT'
      ?
      fetch(url, {
        method: method,
        body: JSON.stringify(object),
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(response => response.json())
        .then(info => save(info))
        .catch(error => alert(`An error has occurred: ${error}`))
      :
      fetch(url, {
        method: method
      })
        .then(response => response.json())
        .then(info => save(info))
        .catch(error => alert(`An error has occurred: ${error}`))
  }

  return {
    infoAPI
  }  
}

