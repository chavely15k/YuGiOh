import { BsEmojiSunglassesFill } from "react-icons/bs";
import '../styles/styles-routes/User.css'
import { Button } from "../components/Button";

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
            path='/Login'>
            Be Admin
          </Button>
          <Button
            path='/Login'>
            Decks
          </Button>
          <Button
            path='/Login'>
            Tournaments
          </Button>
        </div>
      </div>
    </div>
  )
}