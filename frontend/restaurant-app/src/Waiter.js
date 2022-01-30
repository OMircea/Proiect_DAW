import React, {Component} from 'react';
import { variables } from './Variables';

export class Waiter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            waiters: [],
            modalTitle: "",
            w_id: 0,
            w_first_Name: "",
            w_last_Name: "",
            w_restaurantId: 0
        }
    }

    refreshList() {
        fetch(variables.API_URL+'waiter/all/')
        .then(response=>response.json())
        .then(data=> {
            this.setState({waiters:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    change_w_first_Name = (e) => {
        this.setState({w_first_Name:e.target.value});
    }

    change_w_last_Name = (e) => {
        this.setState({w_last_Name:e.target.value});
    }

    change_w_restaurantId = (e) => {
        this.setState({w_restaurantId:e.target.value});
    }

    addClick() {
        this.setState({
            modalTitle: "Add Waiter",
            w_id: 0,
            w_first_Name: ""
        })
    }

    editClick(waiter) {
        this.setState({
            modalTitle: "Edit Client",
            w_id: waiter.id,
            w_first_Name: waiter.first_Name,
            w_last_Name: waiter.last_Name,
            w_restaurantId: waiter.restaurantId
        })
    }

    createClick(){
        fetch(variables.API_URL+'waiter/body/',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                first_Name: this.state.w_first_Name,
                last_Name: this.state.w_last_Name,
                restaurantId: this.state.w_restaurantId
            })
        })
        .then((result)=>{
            alert(result.status);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    updateClick(){
        fetch(variables.API_URL+'waiter/'+this.state.w_id,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                first_name: this.state.w_first_Name,
                last_name: this.state.w_last_Name,
                restaurantid: this.state.w_restaurantId
            })
        })
        .then((result)=>{
            alert(result.status);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    deleteClick(id){
        if (window.confirm('Are you sure?')) {
        fetch(variables.API_URL+'waiter/'+id,{
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
            waiters,
            modalTitle,
            w_id,
            w_first_Name,
            w_last_Name,
            w_restaurantId
        }=this.state;
        console.log(waiters)
        return (
<div>
    <button type = "button" className='btn btn-primary m-2 float-end' 
    data-bs-toggle="modal" 
    data-bs-target="#exampleModal"
    onClick={()=>this.addClick()}>
        Add Waiter
    </button>
                <h3>Waiter page</h3>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>
                                WaiterId
                            </th>
                            <th>
                                First Name
                            </th>
                            <th>
                                Last Name
                            </th>
                            <th>
                                Restaurant id
                            </th>
                            <th>
                                Options
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {waiters.map(waiter=>
                            <tr key={waiter.id}>
                                <td>{waiter.id}</td>
                                <td>{waiter.first_Name}</td>
                                <td>{waiter.last_Name}</td>
                                <td>{waiter.restaurantId}</td>
                                <td>
                                    <button type="button" className="btn btn-light mr-1"
                                    data-bs-toggle="modal" 
                                    data-bs-target="#exampleModal"
                                    onClick={()=>this.editClick(waiter)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil" viewBox="0 0 16 16">
                                        <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z"/>
                                        </svg>
                                    </button>

                                    <button type="button" 
                                    className="btn btn-light mr-1"
                                    onClick={()=>this.deleteClick(waiter.id)}>
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
        <span className="input-group-text">Waiter First Name</span>
        <input type="text" className="form-control"
        value={w_first_Name}
        onChange={this.change_w_first_Name}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">Waiter Last Name</span>
        <input type="text" className="form-control"
        value={w_last_Name}
        onChange={this.change_w_last_Name}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">Waiter Restaurant Id</span>
        <input type="text" className="form-control"
        value={w_restaurantId}
        onChange={this.change_w_restaurantId}/>
       </div>
        
        {w_id==0?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.createClick()}
        >Create</button>
        :null}

        {w_id!=0?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.updateClick()}
        >Update</button>
        :null}

   </div>

</div>
</div> 
</div>

</div>
        )
    }
}