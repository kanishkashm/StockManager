import React, { useEffect, useState } from "react";
import { Col, FormControl, FormGroup, FormLabel, Row } from "react-bootstrap";
import { DropDownList } from "@progress/kendo-react-dropdowns";
import axios from "axios";
import OrderItem from "./OrderItem";
import { DatePicker } from "@progress/kendo-react-dateinputs";
import { Dialog, DialogActionsBar } from "@progress/kendo-react-dialogs";
import { Fade } from "@progress/kendo-react-animation";
import { Notification } from "@progress/kendo-react-notification";

const baseUrl = "https://localhost:7000";

const pageSize = 30;

function Order() {
  const [selectedCustomer, setSelectedCustomer] = useState({});
  const [orderDetails, setOrderDetails] = useState({});
  const [orderItems, setOrderItems] = useState([]);
  const [total, setTotal] = useState(0);
  const [dropDownSetting, setDropDownSetting] = useState({
    skip: 0,
    take: pageSize,
    filterText: '',
  });
  const [customers, setCustomer] = useState([]);
  const [showConfirmDialog, setShowConfirmDialog] = useState(false);
  const [notificationState, setNotificationState] = useState({
    showNotification: false,
    style: 'success',
    message: ''
  });

  const onFilterChange = (event) => {
    console.log("onFilterChange --> filter: ", event.filter);
    const filterText = event.filter.value;
    const dds = dropDownSetting;
    dds.filterText = filterText;
    setDropDownSetting(dds);
    getClientsIdNamesWithPaging();
  }

  const pageChange = (event) => {
    console.log("event: ", event);
    const skip = event.page.skip;
    const take = event.page.take;
    const dds = dropDownSetting;
    dds.skip = skip;
    dds.take = take;
    setDropDownSetting(dds);
    getClientsIdNamesWithPaging();
  };

  useEffect(() => {
    getClientsIdNamesWithPaging();
  }, []);

  const getClientsIdNamesWithPaging = () => {
    console.log("getClientsIdNamesWithPaging --> skip: ", dropDownSetting.skip);
    console.log("getClientsIdNamesWithPaging --> take: ", dropDownSetting.take);
    console.log("getClientsIdNamesWithPaging --> filterText: ", dropDownSetting.filterText);
    axios
      .get(`${baseUrl}/api/v1/client/getClientsIdNamesPaging/${dropDownSetting.skip}/${dropDownSetting.take}?filterText=${dropDownSetting.filterText}`)
      .then((response) => {
        console.log("getClientsIdNames: ", response.data);
        setTotal(response.data.total);
        setCustomer(response.data.clients);
      })
      .catch((err) => {
        console.log("error: ", err);
      });
  }

  const getClientDetails = (clientId) => {
    if (clientId) {
      axios
        .get(`${baseUrl}/api/v1/client/getClientDetails/${clientId}`)
        .then((response) => {
          const customerDetails = response.data;
          console.log("getClientDetails: ", customerDetails);
          const od = {
            ...orderDetails,
            ["address1"]: customerDetails.post1,
            ["address2"]: customerDetails.post2,
            ["address3"]: customerDetails.post3,
            ["suburb"]: customerDetails.post4,
            ["state"]: customerDetails.post5,
            ["postCode"]: customerDetails.postPc,
          };
          setOrderDetails(od);
        });
    } else {
    }
  };

  const onTextChange = (event) => {
    console.log("target: ", event.target);
    console.log("value: ", event.target.value);
    console.log("name: ", event.target.name);
    console.log("onTextChange --> before: ", orderDetails);
    const od = { ...orderDetails, [event.target.name]: event.target.value };
    setOrderDetails(od);
    console.log("onTextChange --> after: ", orderDetails);
  };

  const handleSelectChange = (selectedOption) => {
    console.log("handleSelectChange --> selectedOption: ", selectedOption);
    console.log("handleSelectChange --> orderDetails: ", orderDetails);
    setSelectedCustomer(selectedOption.value);
    const clientId = selectedOption?.value.dclink;
    getClientDetails(clientId);
    const od = { ...orderDetails, ["customer"]: clientId };
    console.log("handleSelectChange --> od: ", od);
    setOrderDetails(od);
  };

  const saveOrder = () => {
    console.log('saveOrder --> customer: ', selectedCustomer);
    console.log('saveOrder --> header: ', orderDetails);
    console.log('saveOrder --> item:', orderItems);
    let invoiceDate = '';
    const pickedDate = new Date(orderDetails.invoiceDate);
    console.log("pickedDate: ", pickedDate);
    if(pickedDate != "Invalid Date") {
      //date format mm/dd/yyyy
      console.log("pickedDate: correct ", pickedDate);
      const month = pickedDate.getMonth();
      const date = pickedDate.getDate();
      const year = pickedDate.getFullYear();
      console.log("Month: ", month);
      console.log("date: ", date);
      console.log("year: ", year);
      invoiceDate = `${month}/${date}/${year}`;
    }

    const stockItemToSave = orderItems.filter(x => x.selectedItemCode?.value).map(y => {
      return {
        stockItemLinkId: y.selectedItemCode?.value,
        quantity: y.quantity,
        price: +y.price,
        tax: y.tax,
        exclAmount: y.exclAmount,
        taxAmount: y.taxAmount,
        inclAmount: y.inclAmount,
        note: y.note
      };
    });
    console.log("stockItemToSave: ", stockItemToSave);

    //check validation goes here

    const orderDetailsToSave = {
      customerId: selectedCustomer?.dclink,
      invoiceNo: orderDetails?.invoiceNo,
      invoiceDate: invoiceDate,
      referenceNo: orderDetails?.referenceNo,
      note: orderDetails?.note,
      totalExcl: orderDetails?.totalExcl,
      totalIncl: orderDetails?.totalIncl,
      totalTax: orderDetails?.totalTax,
      orderItems: stockItemToSave,
    };
    axios.post(`${baseUrl}/api/v1/order`, orderDetailsToSave)
    .then((response) => {
      console.log("response: ", response.data);
      setNotificationState({
        showNotification: true,
        style: 'success',
        message: 'Data has been saved.'
      });
      resetFormData();
      toggleConfirmDialog();
    })
    .catch((err) => {
      console.log("error: ", err);
      setNotificationState({
        showNotification: true,
        style: 'error',
        message: 'Oops! Something went wrong ...'
      });
      toggleConfirmDialog();
    });
  };

  const toggleConfirmDialog = () => {
    setShowConfirmDialog(!showConfirmDialog);
  };

  const resetFormData = () => {
    setSelectedCustomer({});    
    setOrderDetails({});
    setOrderItems([]);
    setTotal(0);
    setDropDownSetting({
      skip: 0,
      take: pageSize,
      filterText: '',
    });
    setCustomer([]);
  };

  return (
    <>
      <form className="container mt-3 mb-3">
        <Row className="mb-3">
          <Col sm={6}>
            <Row className="mb-3">
              <FormGroup controlId="formCustomer" className="col col-sm-12">
                <FormLabel>Customer Name</FormLabel>

                <DropDownList
                  // style={{
                  //   width: "300px",
                  // }}
                  data={customers}
                  textField="name"
                  dataItemKey="dclink"
                  onChange={handleSelectChange}
                  filterable={true}
                  onFilterChange={onFilterChange}
                  virtual={{
                    total: total,
                    pageSize: dropDownSetting.take,
                    skip: dropDownSetting.skip,
                  }}
                  onPageChange={pageChange}
                  popupSettings={{
                    height: "250px",
                  }}
                />
              </FormGroup>
              <FormGroup controlId="formAddress1" className="col col-sm-12">
                <FormLabel>Address 1</FormLabel>
                <FormControl
                  type="name"
                  name="address1"
                  value={orderDetails.address1}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
              <FormGroup controlId="formAddress2" className="col col-sm-12">
                <FormLabel>Address 2</FormLabel>
                <FormControl
                  type="name"
                  name="address2"
                  value={orderDetails.address2}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
              <FormGroup controlId="formAddress3" className="col col-sm-12">
                <FormLabel>Address 3</FormLabel>
                <FormControl
                  type="name"
                  name="address3"
                  value={orderDetails.address3}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
              <FormGroup controlId="formSuburb" className="col col-sm-12">
                <FormLabel>Suburb</FormLabel>
                <FormControl
                  type="name"
                  name="suburb"
                  value={orderDetails.suburb}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
              <FormGroup controlId="formState" className="col col-sm-12">
                <FormLabel>State</FormLabel>
                <FormControl
                  type="name"
                  name="state"
                  value={orderDetails.state}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
              <FormGroup controlId="formPostCode" className="col col-sm-12">
                <FormLabel>Post Code</FormLabel>
                <FormControl
                  type="name"
                  name="postCode"
                  value={orderDetails.postCode}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
            </Row>
          </Col>
          <Col sm={6}>
            <Row className="mb-3">
              <FormGroup controlId="formInvoiceNo" className="col col-sm-12">
                <FormLabel>Invoice No.</FormLabel>
                <FormControl
                  type="name"
                  name="invoiceNo"
                  value={orderDetails.invoiceNo}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
              <FormGroup controlId="formInvoiceDate" className="col col-sm-12">
                <FormLabel>Invoice Date</FormLabel>
                {/* <FormControl
                  type="name"
                  name="invoiceDate"
                  value={orderDetails.invoiceDate}
                  onChange={onTextChange}
                  className="form-control"
                /> */}
                <DatePicker
                  defaultValue={orderDetails.invoiceDate}
                  name="invoiceDate"
                  value={orderDetails.invoiceDate}
                  onChange={onTextChange}
                  format="dd/MMM/yyyy"
                  weekNumber={true}
                />
              </FormGroup>
              <FormGroup controlId="formReferenceNo" className="col col-sm-12">
                <FormLabel>Reference no</FormLabel>
                <FormControl
                  type="name"
                  name="referenceNo"
                  value={orderDetails.referenceNo}
                  onChange={onTextChange}
                  className="form-control"
                />
              </FormGroup>
              <FormGroup controlId="formNote" className="col col-sm-12">
                <FormLabel>Note</FormLabel>
                <FormControl
                  as="textarea"
                  type="name"
                  name="note"
                  value={orderDetails.note}
                  onChange={onTextChange}
                  className="form-control"
                  rows="10"
                />
              </FormGroup>
            </Row>
          </Col>
        </Row>
      </form>
      <br />
      <OrderItem
        orderDetails={orderDetails}
        setOrderDetails={setOrderDetails}
        orderItems={orderItems}
        setOrderItems={setOrderItems}
      />
      <form className="container mt-3 mb-3">
        <Row className="mb-3">
          <Col sm={6}>
            <Row className="mb-3"></Row>
          </Col>
          <Col sm={6}>
            <Row className="mb-3">
              <FormGroup controlId="formTotalExcl" className="col col-sm-12">
                <FormLabel>Total Excl</FormLabel>
                <FormControl
                  type="name"
                  name="totalExcl"
                  value={orderDetails.totalExcl}
                  className="form-control"
                  disabled={true}
                />
              </FormGroup>
              <FormGroup controlId="formTotalTax" className="col col-sm-12">
                <FormLabel>Total Tax</FormLabel>
                <FormControl
                  type="name"
                  name="totalTax"
                  value={orderDetails.totalTax}
                  className="form-control"
                  disabled={true}
                />
              </FormGroup>
              <FormGroup controlId="formTotalIncl" className="col col-sm-12">
                <FormLabel>Total Incl</FormLabel>
                <FormControl
                  type="name"
                  name="totalIncl"
                  value={orderDetails.totalIncl}
                  className="form-control"
                  disabled={true}
                />
              </FormGroup>
            </Row>
          </Col>
        </Row>
      </form>
      <div className="container mt-3 mb-3">
      <Row className="mb-3">
          <Col sm={6}>
            <Row className="mb-3"></Row>
          </Col>
          <Col sm={6}>
            {/* <Row className="mb-3"> */}
            <button
            title="Save Order"
            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
            onClick={toggleConfirmDialog}
          >
            Save Order
          </button>
            {/* </Row> */}
          </Col>
        </Row>
        </div>
        {showConfirmDialog && (
        <Dialog title={"Please confirm"} onClose={toggleConfirmDialog}>
        <p
          style={{
            margin: "25px",
            textAlign: "center",
          }}
        >
          Are you sure you want to save order?
        </p>
        <DialogActionsBar>
          <button
            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base"
            onClick={toggleConfirmDialog}
          >
            No
          </button>
          <button
            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
            onClick={saveOrder}
          >
            Yes
          </button>
        </DialogActionsBar>
      </Dialog>
      )}
      <Fade>
          {notificationState.showNotification && (
            <Notification
              type={{
                style: notificationState.style,
                icon: true,
              }}
              closable={true}
              onClose={() =>
                // setState({
                //   ...state,
                //   success: false,
                // })
                setNotificationState({
                  showNotification: false,
                  style: 'success',
                  message: ''
                })
              }
            >
              <span>{notificationState.message}</span>
            </Notification>
          )}
        </Fade>
    </>
  );
}

export default Order;
