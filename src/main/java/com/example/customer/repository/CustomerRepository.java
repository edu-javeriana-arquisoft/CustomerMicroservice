package com.example.customer.repository;

import com.example.customer.domain.Customer;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Service;


public interface CustomerRepository extends JpaRepository<Customer,Long> {
}
