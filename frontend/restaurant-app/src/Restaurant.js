import React, {Component} from 'react';
import { variables } from './Variables';

export class Restaurant extends Component {
    constructor(props) {
        super(props);

        this.state = {
            restaurants: [],
            modalTitle: "",
            r_id: 0,
            r_name: "",
            r_description: "",
            r_rating: 0
        }
    }

    refreshList() {
        fetch(variables.API_URL+'restaurant/all/')
        .then(response=>response.json())
        .then(data=> {
            this.setState({restaurants:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    change_r_name = (e) => {
        this.setState({r_name:e.target.value});
    }

    change_r_description = (e) => {
        this.setState({r_description:e.target.value});
    }

    change_r_rating = (e) => {
        this.setState({r_rating:e.target.value});
    }

    addClick() {
        this.setState({
            modalTitle: "Add Restaurant",
            r_id: 0,
            r_name: ""
        })
    }

    editClick(res) {
        this.setState({
            modalTitle: "Edit Restaurant",
            r_id: res.id,
            r_name: res.name,
            r_description: res.description,
            r_rating: res.rating
        })
    }

    createClick(){
        fetch(variables.API_URL+'restaurant/body/',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                name: this.state.r_name,
                description: this.state.r_description,
                rating: this.state.r_rating
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
        fetch(variables.API_URL+'restaurant/'+this.state.r_id,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                name: this.state.r_name,
                description: this.state.r_description,
                rating: this.state.r_rating
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
        fetch(variables.API_URL+'restaurant/'+id,{
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
            restaurants,
            modalTitle,
            r_id,
            r_name,
            r_description,
            r_rating
        }=this.state;
        console.log(restaurants)
        return (
<div>
    <button type = "button" className='btn btn-primary m-2 float-end' 
    data-bs-toggle="modal" 
    data-bs-target="#exampleModal"
    onClick={()=>this.addClick()}>
        Add Restaurant
    </button>
                <h3>Restaurant page</h3>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>
                                RestaurantId
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Description
                            </th>
                            <th>
                                Rating
                            </th>
                            <th>
                                Options
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {restaurants.map(res=>
                            <tr key={res.id}>
                                <td>{res.id}</td>
                                <td>{res.name}</td>
                                <td>{res.description}</td>
                                <td>{res.rating}</td>
                                <td>
                                    <button type="button" className="btn btn-light mr-1"
                                    data-bs-toggle="modal" 
                                    data-bs-target="#exampleModal"
                                    onClick={()=>this.editClick(res)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil" viewBox="0 0 16 16">
                                        <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z"/>
                                        </svg>
                                    </button>

                                    <button type="button" 
                                    className="btn btn-light mr-1"
                                    onClick={()=>this.deleteClick(res.id)}>
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
        <span className="input-group-text">Restaurant Name</span>
        <input type="text" className="form-control"
        value={r_name}
        onChange={this.change_r_name}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">Restaurant Description</span>
        <input type="text" className="form-control"
        value={r_description}
        onChange={this.change_r_description}/>
       </div>

       <div className="input-group mb-3">
        <span className="input-group-text">Restaurant Rating</span>
        <input type="text" className="form-control"
        value={r_rating}
        onChange={this.change_r_rating}/>
       </div>
        
        {r_id==0?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.createClick()}
        >Create</button>
        :null}

        {r_id!=0?
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