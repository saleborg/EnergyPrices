import 'bootstrap/dist/css/bootstrap.css';
import EnergyPriceList from './components/EnergyPriceList';

function App() {
  return (
    <>
      <div className="col-lg-8 col-md-7 col-sm-6" align="center">
        <h1>
          Energyprice site
        </h1>
        <p>This site list energy prices</p>
        <EnergyPriceList />
   

      </div>
    </>
  );
}

export default App;
