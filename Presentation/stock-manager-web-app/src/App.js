
import '@progress/kendo-theme-default/dist/all.css';
import './App.css';
import { Calendar } from '@progress/kendo-react-dateinputs';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import Home from './View/Home';
import Order from './View/Order/Order';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <nav style={{ margin: 10 }}>
          <Link to="/" style={{ padding: 5 }}>
          Home
          </Link>
          <Link to="/order" style={{ padding: 5 }}>
          Order
          </Link>
      </nav>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/order" element={<Order />} />
      </Routes>
    </BrowserRouter>
    </div>
  );
}

export default App;
