export const useUniqueId = () => {
  const {v4: uuidv4} = require('uuid')
  const uniqueId = uuidv4()

  return{
    uniqueId
  }
}