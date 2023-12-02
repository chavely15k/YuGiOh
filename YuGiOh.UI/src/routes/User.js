//components
import { BsEmojiSunglassesFill } from "react-icons/bs";
import { Button } from "../components/Button";

//styles
import '../styles/styles-routes/User.css'

export function User(props) {

  return (
    <div
      className="containerPrincipalUser">
      <header className="headerUser">
        <h2>Hello {props.info.nick}</h2>
      </header>
      <div className="infoAdmin">
        <aside className="containerAnimations">
          <div className="headerCards">
            Welcome to our site
            <p className="colorIconHeader">{<BsEmojiSunglassesFill/>}</p>
          </div>
          <div className="containerCards">
            <div className="setCard card"></div>
            <div className="multifaker card"></div>
          </div>
        </aside>
        <div className="containerOptionsUser">
          <Button
            path='/Login/User/RequestsSettings'>
            Manage Requests
          </Button>
          <Button
            path='/Login/User/Decks'>
            Decks
          </Button>
          <Button
            path='/'>
            My Tournaments
          </Button>
        </div>
      </div>
    </div>
  )
}