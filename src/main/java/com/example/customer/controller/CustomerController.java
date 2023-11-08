package com.example.customer.controller;

import com.example.customer.domain.Customer;
import com.example.customer.services.CustomerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Map;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/customers")
public class CustomerController {
    @Autowired
    CustomerService customerService;

    @GetMapping("/get/all")
    public Map<Long, String> getEvents() {
        return customerService.getAllCustomers().stream().collect(Collectors.toMap(Customer::getId, Customer::getName));
    }
}
