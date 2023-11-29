export const useFetch = () => {

  const infoAPI = (url, method, data, object = {}) => {
    fetch(url, {
      method: method,
      body: JSON.stringify(object),
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(response => response.json())
      .then(info => data[0] = info)
      .catch(error => alert(`An error has occurred: ${error}`))
  }

  return {
    infoAPI
  }
}
