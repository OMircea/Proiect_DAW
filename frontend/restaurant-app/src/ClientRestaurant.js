import React, {Component} from 'react';
import { variables } from './Variables';

export class ClientRestaurant extends Component {
    constructor(props) {
        super(props);

        this.state = {
            clientrestaurants: [],
            r_id: 0,
            c_id: 0
        }
    }

    refreshList() {
        fetch(variables.API_URL+'clientrestaurant/all/')
        .then(response=>response.json())
        .then(data=> {
            this.setState({clientrestaurants:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    change_r_id = (e) => {
        this.setState({r_id:e.target.value});
    }

    change_c_id = (e) => {
        this.setState({c_id:e.target.value});
    }

    addClick() {
        this.setState({
            modalTitle: "Add ClientRestaurant",
            r_id: 0,
            c_id: 0
        })
    }

    createClick(){
        fetch(variables.API_URL+'clientrestaurant/body/',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                idrestaurant: this.state.r_id,
                idclient: this.state.c_id
            })
        })
        .then((result)=>{
            alert(result.status);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    deleteClick(id1, id2){
        if (window.confirm('Are you sure?')) {
        fetch(variables.API_URL+'clientrestaurant/'+id1+'/'+id2,{
            method:'DELETE',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        })
        .then((result)=>{
            alert(result.status);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }
    }

    render() {
        const {
            clientrestaurants,
            modalTitle,
            r_id,
            c_id
        }=this.state;
        console.log(clientrestaurants)
        return (
<div>
    <button type = "button" className='btn btn-primary m-2 float-end' 
    data-bs-toggle="modal" 
    data-bs-target="#exampleModal"
    onClick={()=>this.addClick()}>
        Add ClientRestaurant
    </button>
                <h3>ClientRestaurant page</h3>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>
                                RestaurantId
                            </th>
                            <th>
                                ClientId
                            </th>
                            <th>
                                Options
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {clientrestaurants.map(cr=>
                            <tr key={cr.idClient}>
                                <td>{cr.idClient}</td>
                                <td>{cr.idRestaurant}</td>
                                <td>
                                    <button type="button" 
                                    className="btn btn-light mr-1"
                                    onClick={()=>this.deleteClick(cr.idClient, cr.idRestaurant)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash" viewBox="0 0 16 16">
                                        <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                                        <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                                        </svg>
                                    </button>
                                </td>

                            </tr>
                            )}
                    </tbody>

                </table>
<div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
<div className="modal-dialog modal-lg modal-dialog-centered">
<div className="modal-content">
   <div className="modal-header">
       <h5 className="modal-title">{modalTitle}</h5>
       <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"
       ></button>
   </div>

   <div className="modal-body">
       <div className="input-group mb-3">
        <span className="input-group-text">RestaurantId</span>
        <input type="text" className="form-control"
        value={r_id}
        onChange={this.change_r_id}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">ClientId</span>
        <input type="text" className="form-control"
        value={c_id}
        onChange={this.change_c_id}/>
       </div>
        
        
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.createClick()}
        >Create</button>
   </div>

</div>
</div> 
</div>

</div>
        )
    }
}